class WineStore::Customer
  attr_reader :name
  attr_reader :shipping_address
  
  def initialize(name, shipping_address, 
      dependencies = {
        purchases:  WineStore::Purchases.new,
        bill:       WineStore::Bill.new(customer: self)
      })

    @name = name
    @shipping_address = shipping_address

    @purchases = dependencies[:purchases]
    @bill = dependencies[:bill]
  end
 
  def add_purchase(purchase)
    @purchases << purchase
  end
  
  def pay(amount)
    @bill.add_payment amount
  end

  def statement
    update_bill.extend(WineStore::BillFormatter).format
  end

  def update_bill
    @bill.update @purchases.not_billed
  end

  # Deprecated
  def customer_statement
    statement
  end
end

# Deprecated
Customer = WineStore::Customer