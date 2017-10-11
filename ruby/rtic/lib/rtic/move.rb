module RTic
  class Move
    extend Forwardable

    def initialize position, state
      @position = position
      @state = state
      freeze
    end

    attr_reader :state, :position

    def_delegator :state, :player

    def state_after
      state.update position
    end

    def safe?
      possible_rounds.none? do |r|
        r.state_after.lose?(player) || r.state_after.trap?
      end
    end

    def trap?
      state_after.trap?
    end

    def lose?
      return false if winner?
      possible_rounds.any? do |r| 
        r.state_after.lose? state.player
      end
    end

    def winner?
      state_after.winner?
    end

    def possible_rounds
      Rounds.possible self
    end

    # :nocov:
    def inspect
      "Move(#{position.i}, #{position.j})"
    end
    # :nocov:

    def priority
      case
        when state_after.winner? then 1
        when safe? then 2
        else 10
      end
    end
  end
end