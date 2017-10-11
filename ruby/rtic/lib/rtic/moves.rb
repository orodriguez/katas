module RTic
  class Moves
    include Collection

    def best
      min_by &:priority
    end
  end
end