require "equi/version"

module Equi
  def equi
    (0...count).find { |i| sum_left(i) == sum_right(i) } || -1
  end

  def sum_left i
    take(i).sum
  end

  def sum_right i
    drop(i + 1).sum
  end

  def sum
    inject(0) { |s, e| s + e }
  end

  def take i
    super(i).extend Equi
  end

  def drop i
    super(i).extend Equi
  end
end