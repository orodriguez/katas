module RTic
  module Collection
    include Enumerable

    def initialize elements
      @elements = elements.freeze
      freeze
    end
    
    attr_reader :elements
    
    def each &block
      @elements.each &block 
    end

    def [] index
      @elements[index]
    end
    
    def + other
      self.class.new(elements + other.elements)
    end
  end
end