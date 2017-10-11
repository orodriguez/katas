module RTic
  module LinesBuilder
    def build_lines
      horizontal_lines + vertical_lines + diagonal_lines
    end

    protected

    def horizontal_lines
      Lines.new(rows.map { |row| Line.new row })
    end

    def vertical_lines
      Lines.new((0..2).map { |j| Line.new column(j) })
    end

    def diagonal_lines
      Lines.new [first_diagonal_line, second_diagonal_line]
    end

    def first_diagonal_line
      Line.new((0..2).map { |i| self[P[i, i]] })
    end

    def second_diagonal_line
      Line.new((0..2).map { |i| self[P[(2-i), i]] })
    end
  end
end