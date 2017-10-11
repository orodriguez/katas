module Number2Words
  module Digit
    def initialize(value: nil, next_digit: nil)
      @value = value
      @next_digit = next_digit
    end

    attr_reader :value, :next_digit

    Words = { 
      0 => 'zero',
      1 => 'one', 
      2 => 'two',
      3 => 'three',
      4 => 'four',
      5 => 'five',
      6 => 'six',
      7 => 'seven',
      8 => 'eight',
      9 => 'nine'
    }

    def single_word
      Words[value]
    end

    def next_digits
      return value unless next_digit
      "#{value}#{next_digit.next_digits}".to_i
    end

    class << self
      def factory_for significance, value
        case significance
          when 0 then SingleDigit
          when 1 then value == 1 ? FirstTensDigit : TensDigit
          when 2 then HundredsDigit
          when 3 then ThousandsDigit
          #:nocov:
          else raise NotImplementedErrors
          #:nocov:
        end
      end
    end
  end

  class SingleDigit
    include Digit

    def to_words(nil_zero: false)
      return nil if nil_zero and value == 0
      single_word
    end
  end

  class FirstTensDigit
    include Digit

    def to_words
      return exception if exceptions.has_key? next_digits
      "#{next_digit.to_words}teen"
    end

    def exception
      exceptions[next_digits]
    end

    def exceptions
      Exceptions
    end

    Exceptions = {
      10 => 'ten',
      11 => 'eleven',
      12 => 'twelve',
      13 => 'thirteen',
      15 => 'fifteen'
    }
  end

  class TensDigit
    include Digit

    def to_words
      [prefix, next_digit.to_words(nil_zero: true)].compact.join '-'
    end

    def prefix
      Prefixes[value]
    end

    Prefixes = {
      2 => 'twenty',
      3 => 'thrity',
      4 => 'fourty',
      5 => 'fifty',
      6 => 'sixty',
      7 => 'seventy',
      8 => 'eighty',
      9 => 'ninety'
    }
  end

  class HundredsDigit
    include Digit

    def to_words
      return next_digit.to_words if value == 0
      "#{single_word} hundred #{next_digit.to_words}".strip
    end
  end

  class ThousandsDigit
    include Digit

    def to_words
      "#{single_word} thousand #{next_digit.to_words}".strip
    end
  end
end