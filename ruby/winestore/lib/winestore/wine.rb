class WineStore::Wine
  include WineStore::WinePriceCodes
 
  attr_reader :wine_name
  attr_accessor :wine_price_code
 
  def initialize(name, price_code)
    @wine_name = name
    @wine_price_code = price_code
  end

  def price
    @wine_price_code.price
  end
end

# Deprecated
Wine = WineStore::Wine