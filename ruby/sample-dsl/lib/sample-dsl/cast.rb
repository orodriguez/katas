module Sample::Dsl
  class Cast < Array
    def initialize(&block)
      Builder.new(self).instance_eval &block if block_given?
    end

    def add_actor name, character
      self << Actor.new(name, character)
    end
    
    class Builder
      def initialize(cast)
        @cast = cast
      end

      def actor name, attrs
        @cast.add_actor name, attrs[:as]
      end
    end
  end
end