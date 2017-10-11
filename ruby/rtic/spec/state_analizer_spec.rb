require 'spec_helper'

describe RTic::StateAnalyzer do
  context '#trap?' do
    specify do
      State.create([
        [:X, :O, :_],
        [:X, :X, :_],
        [:O, :_, :_]
      ], player: :O).trap?.should be_true
    end

    specify do
      State.create([
        [:X, :_, :X],
        [:_, :O, :_],
        [:O, :_, :X]
      ], player: :O).trap?.should be_true
    end

    specify do
      State.create([
        [:X, :_, :_],
        [:_, :_, :_],
        [:O, :_, :X]
      ], player: :O).trap?.should be_true
    end

    specify do
      State.create([
        [:X, :X, :_],
        [:X, :O, :_],
        [:O, :_, :_]
      ], player: :O).trap?.should be_false
    end

    specify do
      State.create([
        [:X, :_, :_],
        [:X, :X, :_],
        [:O, :O, :_]
      ], player: :O).trap?.should be_false
    end
  end
end