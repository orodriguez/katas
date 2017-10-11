class WineStore::Purchase
  attr_reader :wine 
 
  def initialize(wine)
    @wine = wine
  end

  def bill=(bill)
    @bill = bill
  end

  def added_to_bill
    !@bill.nil?
  end

  def price
    @wine.price
  end

  def product_name
    @wine.wine_name
  end
end

# Deprecated
Purchase = WineStore::Purchase