public class Solution {
    public ListNode MergeKLists(ListNode[] lists) {

	//these two list nodes are necessary to create our linked list.
	//to add nodes in the correct order, we need to have a starting node, or we cannot add
	//the first node because we dont know which one to start at.
	//linkBuilder is how we will travel from node to node and rewrite the node that '.next' 
	//sends us to. mergedList will hang out at the start because once all of the nodes have
	//been properly linked, we will need to return the result starting from the beginning.
	ListNode mergedList = new ListNode(0);
	ListNode linkBuilder = mergedList;

	//this is going to hold the values of each ListNode in the array
	List<int> LLtoList = new List<int>();

	//this will correlate to the number of linked lists in the array
	int index = 0;

	//continue this loop until we finish going through every list in the array
	while (index < lists.Length)
	{
		//continue this through every value in a specific list
		while (lists[index] != null)
		{
			//in the list at lists[index],
			//add the value of the current node, then move to the next node
			LLtoList.Add(lists[index].val);
			lists[index] = lists[index].next;
		}

		//now that we have all the values from that list, move to the next list in the array
		index++;
	}

	//we have extracted all of the ListNode values into an integer array which is easy to manipulate.
	//sort it into ascending order
	LLtoList.Sort();

	//now that the values are in the correct order we just have to convert it back into a linked list
	foreach (var value in LLtoList)
	{
		//we will iterate through the value list and create a new node with that value.
		//we are setting the '.next' value of the current node to a ListNode with the sorted int value
		//then moving the current node to the node we just created.
		linkBuilder.next = new ListNode(value);
		linkBuilder = linkBuilder.next;
	}

	//nodes have been created and linked for every int in the value list.
	//now we can return the ListNodes starting from mergedList.next.
	//remember, we created a starting node at the beginning, but it is not a real value
	//so we return the .next node which is our first real value from the input.
	return mergedList.next;
    }	
}
