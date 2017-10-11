require 'spec_helper'

describe RTic::AI do
  it "should play anywhere" do
    AI.with_state([
      [:_, :_, :_],
      [:_, :_, :_],
      [:_, :_, :_]
    ], player: :X).best_move.should eql P[0, 0]
  end

  it "should win when possible" do
    AI.with_state([
      [:X, :_, :_],
      [:X, :O, :_],
      [:O, :_, :_]
    ], player: :O).best_move.should eql P[0, 2]
  end

  it "should block possible opponent's line" do
    AI.with_state([
      [:X, :O, :X],
      [:_, :O, :_],
      [:_, :_, :_]
    ], player: :X).best_move.should eql P[2, 1]
  end

  it "should block possible opponent's line, case 2" do
    AI.with_state([
      [:O, :_, :_],
      [:_, :X, :_],
      [:O, :_, :_]
    ], player: :X).best_move.should eql P[1, 0]
  end

  it "should avoid traps" do
    AI.with_state([
      [:X, :_, :_],
      [:X, :_, :_],
      [:O, :_, :_]
    ], player: :O).best_move.should eql P[1, 1]
  end
end