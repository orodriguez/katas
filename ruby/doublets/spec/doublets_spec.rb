module Doublets
  def self.find(dic, word, to)
    []
  end
end

describe Doublets do
  subject { Doublets.find dictionary, word, to }

  context 'Empty dictionary' do
    let(:dictionary) { [] }
    let(:word) { '' }
    let(:to) { '' }

    it { is_expected.to eq [] }
  end
end
