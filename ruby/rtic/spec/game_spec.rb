require 'spec_helper'

describe RTic::Game do
  it "should initialize an empty game" do
    expect(Game.new.to_a).to eql [
      [:_, :_, :_],
      [:_, :_, :_],
      [:_, :_, :_]
    ]
  end

  it "should place a move and continue the game" do
    continue = false

    Game.new.move 0, 0, continue: -> (game) do
      continue = true

      expect(game.to_a).to eql [
        [:X, :_, :_],
        [:_, :_, :_],
        [:_, :_, :_]
      ]
    end

    expect(continue).to be_true
  end

  it "should place many moves and alternate the player" do
    expect(Game.new.move(0, 0)
      .move(1, 1)
      .move(2, 2)
      .to_a).to eql [
        [:X, :_, :_],
        [:_, :O, :_],
        [:_, :_, :X]
      ]
  end

  it "should not allow a move in a occupied position" do
    position_occupied = false

    Game.new.move(0, 0)
      .move 0, 0, position_occupied: -> (position) do
        position_occupied = true
        expect(position).to eql P[0, 0]
      end

    expect(position_occupied).to be_true
  end

  it "should notify draw" do
    draw = false

    Game.in_state([
      [:X, :O, :X],
      [:X, :X, :O],
      [:O, :_, :O]
    ]).move(2, 1, draw: ->(game) { draw = true })

    expect(draw).to be_true
  end

  it "should notify horizontal win" do
    win = false

    Game.in_state([
      [:X, :_, :X],
      [:O, :O, :_],
      [:_, :_, :_]
    ]).move(0, 1, win: -> (game) do 
      win = true
      expect(game.winner).to eql :X
      expect(game.winner_lines)
        .to eql [[P[0, 0], P[0, 1], P[0, 2]]]
    end)

    expect(win).to be_true
  end

  it "should notify vertical win" do
    win = false

    Game.in_state([
      [:O, :X, :_],
      [:O, :_, :X],
      [:_, :_, :_]
    ], player: :O).move(2, 0, win: -> (game) do 
      win = true
      expect(game.winner).to eql :O
      expect(game.winner_lines)
        .to eql [[P[0, 0], P[1, 0], P[2, 0]]]
    end)

    expect(win).to be_true
  end

  it "should notify first diagonal win" do
    win = false

    Game.in_state([
      [:X, :O, :O],
      [:_, :_, :_],
      [:_, :_, :X]
    ], player: :X).move(1, 1, win: -> (game) do 
      win = true
      expect(game.winner).to eql :X
      expect(game.winner_lines)
        .to eql [[P[0, 0], P[1, 1], P[2, 2]]]
    end)

    expect(win).to be_true
  end

  it "should notify second diagonal win" do
    win = false

    Game.in_state([
      [:X, :_, :_],
      [:X, :O, :_],
      [:O, :_, :_]
    ], player: :O).move(0, 2, win: -> (game) do 
      win = true
      expect(game.winner).to eql :O
      expect(game.winner_lines)
        .to eql [[P[2, 0], P[1, 1], P[0, 2]]]
    end)

    expect(win).to be_true
  end
end