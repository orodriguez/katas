module Number2Words
  module FixnumExtensions
    def to_words
      Number.new(self).to_words
    end
  end
end

class Fixnum
  include Number2Words::FixnumExtensions
end