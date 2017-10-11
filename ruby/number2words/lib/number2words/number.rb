module Number2Words
  class Number
    def initialize value
      @value = value
    end

    attr_reader :value

    def to_words
      Digits.of(self).to_words
    end

    def to_a
      @value.to_s
        .chars
        .map(&:to_i)
        .reverse
    end
  end
end