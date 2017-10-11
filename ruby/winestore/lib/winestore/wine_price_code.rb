class WineStore::WinePriceCode
  def initialize attrs
    @code =   attrs[:code]
    @price =  attrs[:price]
  end

  def price
    @price
  end
end