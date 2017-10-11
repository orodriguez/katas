require 'spec_helper'

# The equilibrium index of a sequence is an index such that 
# the sum of elements at lower indexes is equal to the sum 
# of elements at higher indexes. For example, in a sequence A:
# A[0]=-7 A[1]=1 A[2]=5 A[3]=2 A[4]=-4 A[5]=3 A[6]=0
# 3 is an equilibrium index, because:
# A[0]+A[1]+A[2]=A[4]+A[5]+A[6]
# 6 is also an equilibrium index, because:
# A[0]+A[1]+A[2]+A[3]+A[4]+A[5]=0
# (The sum of zero elements is zero) 7 is not an equilibrium
# index - because it is not a valid index of sequence A.
# If you still have doubts, here is a precise definition:
# The integer k is an equilibrium index of a sequence 
# A[0],A[1]..,A[n-1] if and only if 0<= k and sum(A[0..(k-1)])=sum(A[(k+1)..(n-1)]). 
# Assume the sum of zero elements is equal to zero. 
#
# Write a function
# int equi(int A[], int n)
# that, given a sequence, returns its equilibrium 
# index (any) or -1 if no equilibrium index exists. 
# Assume that the sequence may be very long.

describe "Equilibrium"  do
  before { subject.extend Equi }
  
  context [] do
    its(:equi) { should eql -1 }
  end

  context [1] do
    its(:equi) { should eql 0 }
  end

  context [1, 2, 3, 4, -1] do
    its(:equi) { should eql 2 }
  end

  context [0, 0, 0, 0, 0, 0] do
    its(:equi) { should eql 0 }
  end

  context [1, -1, 1, -1, 0] do
    its(:equi) { should eql 4 }
  end

  context [1, -1, 1, -1, 0, 0] do
    its(:equi) { should eql 4 }
  end

  context [10 ** 100, 10 ** 100, 0, 2 * 10 ** 100] do
    its(:equi) { should eql 2 }
  end

  context [10 ** 100, -10 ** 100, 0] do
    its(:equi) { should eql 2 }
  end

  context [0, 10 ** 100, -10 ** 100] do
    its(:equi) { should eql 0 }
  end

  context "Huge array" do
    subject do
      left = (-5000..5000).to_a
      central = 0
      right = (-5000..5000).to_a

      (left << central) + right
    end

    its(:equi) { should eql 10001 }
  end
end