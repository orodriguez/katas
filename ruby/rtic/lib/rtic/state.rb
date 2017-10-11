module RTic  
  class State
    include LinesBuilder
    include StateAnalyzer

    def initialize(rows: empty_rows, player: X)
      @rows = rows.map(&:freeze).freeze
      @player = player
      @lines = build_lines
      freeze
    end

    attr_reader :rows, :player, :lines

    def [] position
      rows[position.i][position.j]
    end

    def map_cells
      rows.map { |row| row.map { |cell| yield cell } }
    end

    def update position
      self.class.new(rows: update_rows(position), 
        player: player.opponent)
    end

    def update_rows position
      map_cells do |cell|
        cell.is_at?(position) ? Cell[position, player] : cell
      end
    end

    def winner?
      lines.winners.any?
    end

    def winner
      lines.winners.first.winner
    end

    def winner_lines
      lines.winners
    end

    def column j
      (0..2).map { |i| self[P[i, j]] }
    end

    def draw?
      rows.flatten.none? &:empty?
    end

    def empty_positions
      empty_cells.map(&:position)
    end

    def empty_cells
      rows.flatten.select(&:empty?)
    end

    def to_a
      rows.map { |row| row.map(&:to_sym) }
    end

    # :nocov:
    def inspect
      "\n" + rows.map { |row| row.map(&:value).map(&:to_sym).join ' | ' }
        .join("\n") + "\nplayer: #{player}"
    end
    # :nocov:

    def empty_rows
      [
        [:_, :_, :_],
        [:_, :_, :_],
        [:_, :_, :_]
      ].extend(Rows).to_cells
    end

    class << self
      def create(rows, player: :X)
        new(rows: rows.extend(State::Rows).to_cells, 
          player: Token.for_sym(player))
      end

      alias :from :create
    end

    module Rows
      def map_with_position
        each_with_index.map do |r, i|
          r.each_with_index.map { |sym, j| yield sym, i, j }
        end
      end

      def to_cells
        map_with_position do |sym, i, j| 
          Cell.new P[i, j], Token.for_sym(sym)
        end
      end
    end
  end

end