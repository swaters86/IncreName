# IncreName

I wrote this C#/command-line program for work. It fixes attachment folders, which have numeric names like 1, 2, 3, 4, and so forth, by renaming them to an incremented value. For example, it will rename the folders to 2, 3, 4, and 5 if the original names were 1, 2, 3, and 4, respectively. Any real number can be used to increment the numeric value for the folder name. This is so the ID referenced in an attachment link will match up with the folder name that was generated for the attachment (because there's an upgrade that breaks the syncing for the numbers).

I can't see how somoene else could use this outsideo of my job but maybe it will be useful someone else out there (which would be awesome). You could probably modified it so it renames the folders differently (instead of renaming them to another numeric number).

## How to use it: 

1. Check out the IncreName.exe program which can be found in the following directory: bin/Debug

2. Run the program

3. At this point a command prompt will pop up. It will ask you for the path to the attachments folder (aka the target directory). This directory should have subfolders with numeric names like 1, 2, 3, 4, ... 44, 66, 88, 500, 200, 44, so forth. 

4. Specify the increment amount, for example 2. 

5. Next specify the last modified time of the folder you want the renaming process to start on 

6. Then specify the last modified time of the folder you want the renaming process to stop on

The last modified time should be in this format: 06/19/2015 3:06 PM 

So using  06/19/2015 3:06 PM as the starting last modified time and 06/19/2015 3:07 PM as the stoping as last modified time will rename
folders that have been modified 06/19/2015 3:06 PM  and 06/19/2015 3:07 PM

7. If you used the increment amount of 2 and folders with the names of '68' and '7', for example, fall within the start and stoping last modified times, then those folders will be renamed to '70' and '9', respectively. 

8. The program will exit after it runs but it will generate a log file in the targetr directory before doing so. 


