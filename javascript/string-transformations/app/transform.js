const transform = (transformationsStr, str) => {
  const parseResult = parseTransformations(transformationsStr);

  if (!parseResult.valid())
    return parseResult.error();

  const _transform = createComposedTransformation(parseResult.transformations());

  return _transform(str);
}

const toPascalCase = str =>
  str.split(/(\s)/g) // When a regex with a grupo is passed to split, it includes the delimitator in the results
    .map(token => token.charAt(0).toUpperCase() + token.slice(1).toLowerCase());

const toCamelCase = str => {
  let found = false;
  return toPascalCase(str)
    .map(token => {
      if (!found && token.match(/\w+/)) {
        found = true;
        return token.toLowerCase();
      }

      return token;
    });
};

const toSnakeCase = str =>
  str.split(/[,!@#$%^&*()\s]/).join('_');

const pack = str => str.split(/[\t\n\d\r\s]/).join('');

const handlers = {
  '': str => str,
  'Lowercase': str => str.toLowerCase(),
  'Uppercase': str => str.toUpperCase(),
  'Trim-Start': str => str.trimLeft(),
  'Trim-End': str => str.trimRight(),
  'PascalCase': str => toPascalCase(str).join(''),
  'CamelCase': str => toCamelCase(str).join(''),
  'SnakeCase': str => toSnakeCase(str),
  'Pack': pack
};

const parseTransformations = transformations => {
  const results = transformations.split('=>')
    .map(parseTransformation);

  return createParseResult(results);
};

const parseTransformation = transformationStr => {
  const transformation = handlers[transformationStr];
  return transformation
    ? { valid: true, token: transformationStr, handler: transformation }
    : { valid: false, token: transformationStr };
};

const compose = (f, g) => a => g(f(a));

const createComposedTransformation = transformations =>
  transformations
    .reduce((composed, current) => compose(composed, current));

const createParseResult = parsedTransformations => ({
  valid: () => !parsedTransformations.some(r => !r.valid),

  error: () => {
    const invalid = parsedTransformations.find(r => !r.valid);
    return `Invalid Transformation "${invalid.token}"`;
  },

  transformations: () => parsedTransformations.map(t => t.handler)
});

module.exports = transform;