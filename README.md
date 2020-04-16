# TreeMatrixSorting
This Class provides a Routine to rearrange a strings-Matrix with column by column 
gruop reordering, following a tree schema

Example: Let's assume the input Matrix is like this one below

	h01 g01 x-1 ###
	h03 d01 d01 x-2
	h02 a01 x-3 ###
	h03 g01 f01 x-1
	h01 b01 x-3 ###
	h02 d01 d01 x-1
	h01 d02 x-9 ###
	h03 a01 x-8 ###
	h01 d02 d01 x-9
	h02 g01 f01 x-2
	h02 a01 x-8 ###
	h01 d01 d01 x-9
	h02 g01 f01 x-2

The Output of the Routine will be this

	h01 g01 x-1 ###
		------------->
	h01 b01 x-3 ###
	    ------------->
	h01 d02 x-9 ###
			--------->
	h01 d02 d01 x-9
	    ------------->
	h01 d01 d01 x-9
	----------------->
	h03 a01 x-8 ###
	    ------------->
	h03 g01 f01 x-1
	    -------------> 
	h03 d01 d01 x-2
	----------------->
	h02 a01 x-3 ###
			--------->
	h02 a01 x-8 ###
	    ------------->
	h02 g01 f01 x-2
	           ------>
	h02 g01 f01 x-2
		------------->
	h02 d01 d01 x-1
 
 Notice that the sorting of the first column creates 3 column groups h01, h02 and h02
 The groups takes all the elements from left to right, so the rearranging in the 2-nd 
 column will be operated in three indipendent sectors of the same column. So goes on 
 in the 3-th column. The dashes have be putted just to mark the groups edges.

 The purpose of the routine was to rearrange a badly given set of leaf (last elements
 on right side of matrix, for instance "x-1", "x-2", etc..) with given ancestors nodes.
 Doing so, it is easier to look up the list of ancestors.

 The main assumption  is that all same generation "brother" elements are unique, so 
 that the recurring names in a column group refer to the same item


	  