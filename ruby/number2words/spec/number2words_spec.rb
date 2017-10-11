require 'spec_helper'

describe 'Convert a number to words' do
  context 'single digit' do
    specify { expect(0.to_words).to eql 'zero' }
    specify { expect(1.to_words).to eql 'one' }
    specify { expect(2.to_words).to eql 'two' }
    specify { expect(3.to_words).to eql 'three' }
    specify { expect(4.to_words).to eql 'four' }
    specify { expect(5.to_words).to eql 'five' }
    specify { expect(6.to_words).to eql 'six' }
    specify { expect(7.to_words).to eql 'seven' }
    specify { expect(8.to_words).to eql 'eight' }
    specify { expect(9.to_words).to eql 'nine' }
  end

  context 'teens' do
    specify { expect(10.to_words).to eql 'ten' }
    specify { expect(11.to_words).to eql 'eleven' }
    specify { expect(12.to_words).to eql 'twelve' }
    specify { expect(13.to_words).to eql 'thirteen' }
    specify { expect(14.to_words).to eql 'fourteen' }
    specify { expect(15.to_words).to eql 'fifteen' }
    specify { expect(18.to_words).to eql 'eightteen' }
    specify { expect(19.to_words).to eql 'nineteen' }
  end

  context 'twenties' do
    specify { expect(20.to_words).to eql 'twenty' }
    specify { expect(21.to_words).to eql 'twenty-one' }
    specify { expect(24.to_words).to eql 'twenty-four' }
  end

  context 'thrities' do
    specify { expect(30.to_words).to eql 'thrity' }
    specify { expect(35.to_words).to eql 'thrity-five' }
  end

  context 'fourties' do
    specify { expect(40.to_words).to eql 'fourty' }
    specify { expect(47.to_words).to eql 'fourty-seven' }
  end

  context 'fifties' do
    specify { expect(50.to_words).to eql 'fifty' }
    specify { expect(52.to_words).to eql 'fifty-two' }
  end

  context 'sixties' do
    specify { expect(60.to_words).to eql 'sixty' }
    specify { expect(69.to_words).to eql 'sixty-nine' }
  end

  context 'seventies' do
    specify { expect(70.to_words).to eql 'seventy' }
    specify { expect(78.to_words).to eql 'seventy-eight' }
  end

  context 'eighties' do
    specify { expect(80.to_words).to eql 'eighty' }
    specify { expect(86.to_words).to eql 'eighty-six' }
  end

  context 'nineties' do
    specify { expect(90.to_words).to eql 'ninety' }
    specify { expect(99.to_words).to eql 'ninety-nine' }
  end

  context 'hundreds' do
    specify { expect(100.to_words).to eql 'one hundred' }
    specify { expect(220.to_words).to eql 'two hundred twenty' }
    specify { expect(399.to_words).to eql 'three hundred ninety-nine' }
    specify { expect(401.to_words).to eql 'four hundred one' }
  end

  context 'thousands' do
    specify { expect(1000.to_words).to eql 'one thousand'}
    specify { expect(3010.to_words).to eql 'three thousand ten'}
    specify { expect(2004.to_words).to eql 'two thousand four'}
    specify { expect(1020.to_words).to eql 'one thousand twenty'}
    specify { expect(1100.to_words).to eql 'one thousand one hundred' }
    specify { expect(9366.to_words).to eql 'nine thousand three hundred sixty-six' }
  end
end