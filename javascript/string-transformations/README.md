String Transformations

Given the following basic string transformations (string to string functions):

● None​: Returns the same input string

● Uppercase​: Returns the input string with all uppercase characters

● Lowercase​: Returns the input string with all lowercase characters

● Trim-Start​: Removes spaces and non-printable characters from the beginning of the

input string

● Trim-End​: Removes spaces and non-printable characters at the end of the input string

● PascalCase​: Assumes that the string is an identifier such as "words counter", and that

every initial character must be in uppercase. For that input, the transformation should

output "Words Counter". No spaces are eliminated.

● camelCase​: Similar to PascalCase​, but without capitalizing the first letter of the first

word., so our previous example should output "words Counter". No spaces are

eliminated.

● Snake_case: replace all spaces, and punctuation marks with an underscore. So "hello.

world" becomes "hello_world".

● Pack​: remove all whitespaces and non-printable characters from the input string. "Hello

World" becomes "HelloWorld".

You should be able to combine all transformation in any given order and quantity. For example,

if build the following combination:

● Trim-Start=>Trim-End=>PascalCase=>Pack and we apply it to the given input "

to be or not to be: that is the question. ", the resulting string

must be: "ToBeOrNotToBeThatIsTheQuestion".

● You could also build new transformation based on the basic ones, like Trim, that is

Trim-Start=>Trim-End.

Transformations should be applied from start (left) to end (right). Your component must accept

two arguments:

● The combination of transformations, a string with the following structure:

"TransformationA=>TransformationB=>TransformationC...=>Transfor

mationN"

● The input string

So if your component is named Transformer, we must be able to do the following:

Transformer ​transformer = new

Transformer​("Trim-Start=>Trim-End=>PascalCase=>Pack");

String ​output = transformer.Transform(" to be or not to be: that is the

question. ");

// output must be "ToBeOrNotToBeThatIsTheQuestion"

Alternatively, we could write

Transformer ​transformer = new Transformer​();

String ​output =

transformer.Transform("Trim-Start=>Trim-End=>PascalCase=>Pack", " to

be or not to be: that is the question. ");

// output must be "ToBeOrNotToBeThatIsTheQuestion"


# Thinks I leaned

* There is no string.replaceAll in javascript. Used a trick with split.

* Local functions make the main logic hard to read