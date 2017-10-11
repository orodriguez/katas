class WineStore::Bill
  def initialize(dependencies = {})
    @customer = dependencies[:customer]
    @purchases = dependencies.fetch(:purchases) { 
      WineStore::Purchases.new }
    @payments = dependencies.fetch(:payments) { 
      WineStore::Payments.new }
  end

  def add_payment(amount)
    @payments.add amount
    balance
  end

  def update new_purchases
    new_purchases.set_bill self
    @purchases.add_all new_purchases
    self
  end

  def balance
    @purchases.total_amount - @payments.total_amount
  end
end