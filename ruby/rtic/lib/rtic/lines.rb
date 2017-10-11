module RTic
  class Lines
    include Collection

    def winners
      select { |l| l.is_winner? }
    end
  end
end