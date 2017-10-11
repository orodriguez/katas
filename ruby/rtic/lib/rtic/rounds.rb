module RTic
  class Rounds
    include Collection

    class << self
      def possible move
        new move.state_after
          .possible_moves
          .map { |next_move| Round.new move, next_move }
      end
    end
  end

  class Round
    def initialize first_move, second_move
      @first_move = first_move
      @second_move = second_move
      freeze
    end

    attr_reader :first_move, :second_move

    def state_after
      second_move.state_after
    end

    # :nocov:
    def inspect
      "Round(#{first_move.inspect}, #{second_move.inspect})"
    end
    # :nocov:
  end
end