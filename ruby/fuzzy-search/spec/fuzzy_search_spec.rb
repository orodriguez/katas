require 'spec_helper'

describe "Fuzzy Search" do
  let(:verses) { [
    "Love is good",
    "Chocolate is sweet",
    "Snow is cold",
    "Good is not evil",
    "I love dogs"
  ] }

  subject { verses.fuzzy_search(pattern) { |match| "[#{match}]" } }

  context "empty pattern" do
    let(:pattern) { "" }
    it { should eql [] }
  end

  context "single character" do
    context "v" do
      let(:pattern) { "v" }
      it { should eql ["Lo[v]e is good", 
        "Good is not e[v]il", "I lo[v]e dogs"] }
    end

    context "c" do
      let(:pattern) { "c" }
      it { should eql ["[C]ho[c]olate is sweet", "Snow is [c]old"] }
    end

    context "l" do
      let(:pattern) { "l" }
      it { should eql ["[L]ove is good", "Choco[l]ate is sweet", 
        "Snow is co[l]d", "Good is not evi[l]", "I [l]ove dogs"] }
    end
  end

  context "character sequence" do
    context "words" do
      context "good" do
        let(:pattern) { "good" }
        it { should eql ["Love is [g][o][o][d]", "[G][o][o][d] is not evil"] }
      end

      context "love" do
        let(:pattern) { "love" }
        it { should eql ["[L][o][v][e] is good", "I [l][o][v][e] dogs"] }
      end
    end

    context "with characters in between" do
      context "is" do
        let(:pattern) { "is" }
        it { should eql ["Love [i][s] good",
          "Chocolate [i][s] sweet",
          "Snow [i][s] cold",
          "Good [i][s] not evil",
          "[I] love dog[s]"] }
      end

      context "oo" do
        let(:pattern) { "oo" }
        it { should eql ["L[o]ve is g[o]od",
          "Ch[o]c[o]late is sweet",
          "Sn[o]w is c[o]ld",
          "G[o][o]d is not evil",
          "I l[o]ve d[o]gs"] }
      end

      context "od" do
        let(:pattern) { "od" }
        it { should eql ["L[o]ve is goo[d]",
          "Sn[o]w is col[d]",
          "G[o]o[d] is not evil",
          "I l[o]ve [d]ogs"] }
      end

      context "si" do
        let(:pattern) { "si" }
        it { should eql [ "[S]now [i]s cold", 
          "Good i[s] not ev[i]l" ] }
      end

      context "ooo" do
        let(:pattern) { "ooo" }
        it { should eql ["L[o]ve is g[o][o]d", 
          "G[o][o]d is n[o]t evil"] }
      end
    end
  end

  context "without wrapping" do
    subject { verses.fuzzy_search(pattern) }

    context "good" do
      let(:pattern) { "good" }
      it { should eql ["Love is good", "Good is not evil"] }
    end

    context "si" do
      let(:pattern) { "si" }
      it { should eql [ "Snow is cold", 
        "Good is not evil" ] }
    end
  end

  context "nil" do
    let(:pattern) { nil }
    it { should eql [] }
  end

  context "space" do
    let(:pattern) { " " }
    it { should eql ["Love[ ]is[ ]good", 
      "Chocolate[ ]is[ ]sweet", 
      "Snow[ ]is[ ]cold", 
      "Good[ ]is[ ]not[ ]evil", 
      "I[ ]love[ ]dogs"] }
  end

  context "not match" do
    context "xx" do
      let(:pattern) { "xx" }
      it { should eql [] }
    end

    context "oooo" do
      let(:pattern) { "oooo" }
      it { should eql [] }
    end
  end
end