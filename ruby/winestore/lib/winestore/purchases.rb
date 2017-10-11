class WineStore::Purchases
  include WineStore::CollectionWrapper

  def <<(purchase)
    @objects << purchase
  end

  def add_all(objects)
    @objects += objects.to_a
    self
  end

  def total_amount
    inject(0) do |total, purchase| 
      total += purchase.price 
    end
  end

  def set_bill(bill)
    each { |purchase| purchase.bill = bill }
  end

  def not_billed
    select { |purchase| !purchase.added_to_bill }
  end
end