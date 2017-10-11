module RTic
  class Cell
    def initialize position, value
      @position = position
      @value = value
      freeze
    end

    attr_reader :position, :value

    def is_at? position
      self.position.eql? position
    end

    def to_sym
      value.to_sym
    end

    def empty?
      @value == E
    end

    class << self
      alias :[] :new
    end
  end
end