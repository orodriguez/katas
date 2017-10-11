require 'spec_helper'

describe Move do
  context "#safe?" do
    specify do
      Move.new(P[0, 1], State.from([
        [:X, :_, :_],
        [:X, :_, :_],
        [:O, :_, :_]
      ], player: :O)).safe?.should be_false
    end

    specify do
      Move.new(P[1, 1], State.from([
        [:X, :_, :_],
        [:X, :_, :_],
        [:O, :_, :_]
      ], player: :O)).safe?.should be_true
    end

    specify do
      Move.new(P[1, 1], State.from([
        [:X, :_, :_],
        [:_, :_, :_],
        [:O, :_, :X]
      ], player: :O)).safe?.should be_false
    end
  end
end