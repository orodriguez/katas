module FuzzySearch::StringExtensions
  def fuzzy_mark pattern, &block
    return self if pattern == ""
    a, b, c = partition /#{pattern[0]}/i
    a + yield(b) + c.fuzzy_mark(pattern[1..-1], &block)
  end
end

class String
  include FuzzySearch::StringExtensions
end