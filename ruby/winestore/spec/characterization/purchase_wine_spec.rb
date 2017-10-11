require 'spec_helper'

describe "Purchase wine" do
  let(:omar) { Customer.new 'Omar', 
      '33, Gaspar P., Sto. Dgo., Dominican Republic' }

  before(:each) {
    omar.add_purchase Purchase.new(
      Wine.new 'Loon', Wine::ECONOMY)
    omar.add_purchase Purchase.new(
      Wine.new 'Loon', Wine::ECONOMY)
    omar.add_purchase Purchase.new(
      Wine.new 'Bogle', Wine::POPULAR)
    omar.add_purchase Purchase.new(
      Wine.new 'Premium wine', Wine::PREMIUM)
    omar.add_purchase Purchase.new(
      Wine.new 'Super wine', Wine::SUPER_PREMIUM)
    omar.add_purchase Purchase.new(
      Wine.new 'Ultra wine', Wine::ULTRA_PREMIUM)
    omar.add_purchase Purchase.new(
      Wine.new 'Prehistoric Reserve', Wine::LUXURY)
  }

  describe :customer_statement do
    context "first time called" do
      subject { omar.customer_statement }

      it { should match "Statement for Omar" }
      it { should match "Loon.+3" }
      it { should match "Bogle.+7" }
      it { should match "Prehistoric Reserve.+17" }
      it { should match "Total Amount is.+66" }
      it { should match "Balance Owing is.+66" }
    end

    context "called a second time with a new purchase" do
      before do 
        omar.customer_statement

        omar.add_purchase Purchase.new(
          Wine.new 'Another', Wine::ECONOMY)
      end

      subject { omar.customer_statement }

      it { should match "Total Amount is.+69" }
      it { should match "Balance Owing is.+69" }
    end
  end

  describe :balance_after_payment do
    before { omar.customer_statement }
    subject { omar.pay 30 }
    it { should == 36 }
  end

  # TODO Check added to bill
end