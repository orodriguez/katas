module RTic
  module StateAnalyzer
    def possible_moves
      Moves.new empty_positions.map { |p| Move.new p, self }
    end

    def trap?
      !draw? and possible_moves.all? { |m| m.lose? or m.trap? } 
    end

    def lose? player
      winner? and winner.eql? player.opponent
    end
  end
end