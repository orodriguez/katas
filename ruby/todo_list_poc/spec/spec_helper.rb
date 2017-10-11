require_relative '../lib/todo_list'

require 'pry'
require 'rspec/autorun'

if ENV["INTEGRATION"]
  require 'integration_spec_helper'
else
  require 'unit_spec_helper'
end