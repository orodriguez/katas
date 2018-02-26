module Doublets
  def self.find(dic, word, to)
    # Implementation
  end
end

describe Doublets do
  examples = [
    {from: 'door', to: 'lock', expected: ['door', 'boor', 'book', 'look', 'lock']},
    {from: 'bank', to: 'loan', expected: ['bank', 'bonk', 'book', 'look', 'loon', 'loan']},
    {from: 'wheat', to: 'bread', expected: ['wheat', 'cheat', 'cheap', 'cheep', 'creep', 'creed', 'breed', 'bread']},
  ]

  examples.each do |example|
    context "when #{example.inspect}" do
      subject { Doublets.find dictionary, example[:word], example[:to] }

      it { is_expected.to eq example[:expected] }
    end
  end

  let :dictionary do
    [
      'door',
      'boor',
      'book',
      'look',
      'lock',
      'bank',
      'bonk',
      'book',
      'wheat',
      'cheat',
      'cheap',
      'cheep',
      'creep',
      'creed',
      'breed',
      'bread',
    ]
  end
end
