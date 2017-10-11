module Sample::Dsl
  class Actor
    attr_accessor :name, :character

    def initialize name, character
      @name = name
      @character = character
    end
  end
end