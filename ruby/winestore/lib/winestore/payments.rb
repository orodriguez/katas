class WineStore::Payments
  include WineStore::CollectionWrapper

  def total_amount
    inject(0) do |total, payment| 
      total += payment.amount 
    end
  end
  
  def add(amount)
    @objects << WineStore::Payment.new(amount)
  end
end