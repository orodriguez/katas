module RTic
  class AI
    extend Forwardable

    def initialize state
      @state = state
    end

    attr_reader :state

    def_delegators :state, :possible_moves

    def best_move
      possible_moves.best.position
    end

    class << self
      def with_state rows, player: :X
        new State.from(rows, player: player)
      end
    end
  end
end