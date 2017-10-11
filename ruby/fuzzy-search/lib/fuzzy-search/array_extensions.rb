module FuzzySearch::ArrayExtensions
  def fuzzy_search(pattern, &block)
    return [] if pattern.nil? || pattern == "" 
    regex = /#{pattern.split('').join ".*"}/i
    result = select { |str| str =~ regex }
    return result unless block_given?
    result.map do |str| 
      str.gsub(regex) { |match| match.fuzzy_mark pattern, &block } 
    end
  end
end

class Array
  include FuzzySearch::ArrayExtensions
end