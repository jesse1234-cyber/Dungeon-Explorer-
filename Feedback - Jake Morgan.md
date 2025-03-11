# Feedback

	Jake Morgan

## Game.cs 

### Error Catching:
	Recommend adding more error catching. Possibly work in strings to avoid any Parse 	errors. For line 38 & 49.
	
	Suggestion, create a list for valid inputs each time you get an input allowing you to 	see if the user has entered an input that is in the list of valid inputs. This could 	also be a function.

### Menu System:
	Could move most menu functionality into the menuSystem() procedure. This could 	improve the maintainability.

## Player.cs

Good layout of features, and efficient way to return the inventory contents.

## Room.cs

I like how you implemented HasItem()


### Get Description:
	GetDescription() is a required function for the assessment so id make sure you have 	that or similar.

### Item Removal:
	Not necessary but Id maybe suggest changing it to string.Empty oppose to Null to 	avoid null reference exceptions. This would still work with HasItem().


# Checklist:

## Pass standard:
	
1. [/] The code compiles and runs.
2. [/] The player can explore at least one room.
3. [/] Object instantiation, method calls evident.
4. [.] There is code review from two students.
5. [/] Handle invalid commands gracefully without crashing the program.

## 2:2 standard:

1. [.]  Rooms can contain multiple items or monsters.
2. [.]  The Testing class is used.
3. [/]  The player can pick up items through an implementation of the
        Player.PickUpItem() method.
4. [/]  The C# style guide is followed partially.
5. [?]  At least one room has a description and can contain one item or one
	monster. These functionalities are given by the Room.GetDescription() method.
6. [/]  Method calls from ‘Main’ to methods in other classes

## 2:1 standard:

1. [?]  Pull Requests and code reviews are noted
2. [?]  You have taken account of the reviews and merging your changes.
3. [/]  There is a complete implementation of your code with no issues.
4. [/]  Commenting is mostly through the code files.
5. [/]  There are at least one Game and Player objects.
6. [?]  There is evidence of testing.
7. [/]  Error handling is performed well but there are still issues.
8. [/]  There is clear evidence of object-oriented features such as classes, object 	instantiation, encapsulation and methods.

## First standard:

1. [?]  You have taken effective account of the reviews by merging your
	changes or suggesting alternative approaches.
2. [?]  The video demonstrates a critical reflection and that you learned from
	the assignment’s experience.
3. [.]  The implementation is complete with excellent error handling.
4. [.]  The C# style guide is shown to be adhered to. XML documenting
	comments are throughout the code.
5. [.]  The testing class uses ‘debug.assert’ to verify aspects of the code.
6. [/]  The implementation of classes, object instantiation, encapsulation
	and methods are complete and with no issues.



