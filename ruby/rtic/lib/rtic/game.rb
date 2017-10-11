module RTic
  class Game
    extend Forwardable

    def initialize state = State.new
      @state = state
      freeze
    end

    attr_reader :state, :current_player

    def_delegators :state, 
      :winner?, 
      :winner_lines,
      :to_a, 
      :draw?

    def winner
      state.winner.to_sym
    end

    def winner_lines
      state.winner_lines.map(&:positions)
    end

    def move(i, j, 
        continue: -> (game) {}, 
        position_occupied: -> (position) {},
        draw: -> (game) {},
        win: -> (game) {})
      position = P[i, j]
      
      unless state[position].empty?
        position_occupied[position]
        return self
      end 
      
      self.class.new(state.update(position)).tap do |game|
        return win[game] if game.winner?
        return draw[game] if game.draw?
        continue[game]
      end
    end

    class << self
      def in_state(rows, player: :X)
        new State.from rows, player: player
      end
    end
  end
end