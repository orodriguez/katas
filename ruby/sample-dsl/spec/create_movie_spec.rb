require 'spec_helper'
include Sample::Dsl

describe "Create movie" do
  let(:movie) do
    Movie.new :name => 'Die Hard' do
      director 'John McTiernan'

      writers ['Roderick Thorp', 'Jeb Stuart']

      cast do
        actor 'Bruce Willis', :as => 'John McClane'
        actor 'Bonnie Bedelia',       :as => 'Holly McClane'
        actor 'Reginald VelJohnson',  :as => 'Powell'
      end
    end
  end

  subject { movie }

  its(:name) { should eql 'Die Hard' }
  its(:director) { should eql 'John McTiernan' }
  its(:writers) { should include 'Roderick Thorp' }

  describe :cast do
    subject { movie.cast }

    its(:count) { should eql 3 }

    describe :fist_actor do
      subject { movie.cast.first }

      its(:name) { should eql 'Bruce Willis' }

      its(:character) { should eql 'John McClane' }
    end
  end
end