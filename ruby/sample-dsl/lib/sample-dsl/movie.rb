module Sample::Dsl
  class Movie
    attr_reader :name, :director, :writers, :cast

    def initialize(attrs, &block)
      @name = attrs[:name]

      Builder.new(self).instance_eval &block if block_given?
    end

    class Builder
      def initialize(movie)
        @movie = movie
      end

      def director name
        @movie.instance_variable_set :@director, name
      end

      def writers list
        @movie.instance_variable_set :@writers, list
      end

      def cast &block
        @movie.instance_variable_set :@cast, Cast.new(&block)
      end
    end
  end
end