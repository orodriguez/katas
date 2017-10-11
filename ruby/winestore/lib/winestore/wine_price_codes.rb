module WineStore::WinePriceCodes
  ECONOMY       = WineStore::WinePriceCode.new(code: 0, price: 3)
  POPULAR       = WineStore::WinePriceCode.new(code: 1, price: 7)
  PREMIUM       = WineStore::WinePriceCode.new(code: 2, price: 10)
  SUPER_PREMIUM = WineStore::WinePriceCode.new(code: 3, price: 12)
  ULTRA_PREMIUM = WineStore::WinePriceCode.new(code: 4, price: 14)
  LUXURY        = WineStore::WinePriceCode.new(code: 5, price: 17)
end