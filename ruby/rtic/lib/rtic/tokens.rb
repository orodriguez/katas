module RTic
  class Token
    class << self
      def for_sym sym
        case sym
          when :X then X
          when :O then O
          when :_ then E
        end
      end
    end
  end

  class X
    class << self
      def opponent; O; end

      def to_sym; :X; end
    end
  end

  class O
    class << self
      def opponent; X; end

      def to_sym; :O; end
    end
  end


  class E
    class << self
      def to_sym; :_; end
    end
  end
end