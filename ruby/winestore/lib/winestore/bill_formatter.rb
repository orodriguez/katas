module WineStore::BillFormatter
  def format
    ["Statement for #{@customer.name}",
    @purchases.map { |p| "\t#{p.product_name}\t#{p.price}" },
    "Total Amount is #{@purchases.total_amount}",
    "Balance Owing is #{balance}"].join "\n"
  end
end