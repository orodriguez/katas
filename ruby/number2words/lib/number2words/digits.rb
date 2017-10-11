module Number2Words
  class Digits
    include Enumerable

    def initialize number
      @number = number
      @digits = []
      number.to_a.each { |n| add n }
    end

    def each &block
      @digits.each &block
    end

    def add n
      self << Digit.factory_for(count, n)
        .new(value: n, next_digit: most_significant_digit)
    end

    def << n
      @digits << n
    end

    def last
      @digits.last
    end

    def to_words
      most_significant_digit.to_words
    end

    alias :most_significant_digit :last

    class << self
      def of number
        new number
      end
    end
  end
end