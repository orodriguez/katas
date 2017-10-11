module RTic
  class Position
    def initialize i, j
      @i = i
      @j = j
      freeze
    end

    attr_reader :i, :j

    def eql? other
      self.i == other.i and self.j == other.j
    end

    def inspect
      "P[#{i},#{j}]"
    end

    class << self
      alias :[] :new
    end
  end

  P = Position
end