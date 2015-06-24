# IncreName

I wrote this program for work. Unfortunately, some there's an upgrade for our software that tends to break attachments folders which have numeric names like 1, 2, 3, 4, and so forth. In addition, links for those attachments reference the original folder names , so an attachment request could look like this /attachments&id=5. However, the upgrade might generate a folder for the attachment and use 6 instead of 5. Unfortunately the id number never gets updated in the link, so we fixt his by renaming the folders so they match the ID referenced in the link for the attachment (so the links point to the correct folder).

This a C# program that can rename a set of folders with numeric names such as 1, 2, 3, 4, to 2, 3, 4, 5, repectively, if the increment amount supplied by the user is 1.  

## How to use it: 

1. Check out the IncreName.exe program which can be found in the following directory: bin/Debug

2. Run the program

3. At this point a command prompt will pop up. It will ask you for the path to the attachments folder (aka the target directory). This directory should have subfolders with numeric names like this:  

+---1
+---10
+---11
+---12
+---13
+---14
+---15
+---17
+---2
+---3
+---379
+---381
+---4
+---5
+---6
+---64
+---65
+---66
+---67
+---68
+---7

4. Specify the increment amount, for example 2. 

5. Next specify the last modified time of the folder you want the renaming process to start on 

6. Then specify the last modified time of the folder you want the renaming process to stop on

The last modified time should be in this format: 06/19/2015 3:06 PM 

So using  06/19/2015 3:06 PM as the starting last modified time and 06/19/2015 3:07 PM as the stoping as last modified time will rename
folders that have been modified 06/19/2015 3:06 PM  and 06/19/2015 3:07 PM

7. If you used the increment amount of 2 and folder '68' and '7' in the above list fall within those last modified times, then those folders should be renamed to '70' and '9', respectively. 

