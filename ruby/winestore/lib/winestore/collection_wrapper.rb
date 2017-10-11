module WineStore::CollectionWrapper
  include Enumerable
  
  def initialize(objects = [])
    @objects = objects
  end

  def each(&block)
    @objects.each &block
  end

  def select(&predicate)
    self.class.new @objects.select(&predicate)
  end
end