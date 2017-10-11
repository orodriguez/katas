module RTic
  class Line
    include Enumerable

    def initialize cells
      @cells = cells.freeze
      freeze
    end

    def each &block; @cells.each &block; end

    def all_eql?
      map(&:value).uniq.size == 1
    end

    def winner
      first.value if is_winner?
    end

    def is_winner?
      all_eql? and !first.empty?
    end

    def positions
      map(&:position)
    end
  end
end