   M S B A M L   `   `   `  ����C  ?ToDoList, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:ToDoList.ViewsToDoList.Views  5   	   9!clr-namespace:ToDoList.ViewModelsToDoList.ViewModels  5   	       ToDoList.Views.Editor   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:ToDoList.Views     5   	   1vms!clr-namespace:ToDoList.ViewModels     5   	   -   5          �Name$  editorWindow��5   	   $��195.708��5	   '   $��258.798��68    � 
ResizeMode$ NoResize=�6H   ���	#FFC3BEA0 � Title 6	   �� *WindowTitle+ � DataContext 5      )   #ToDoList.ViewModels.EditorViewModel  5   
   .��5      � ��5   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      �  � Color$ 	#FF9F9F98��6    � Offset$ 0Q�61   � 5      $ White��6   $ 1Q�6-   5      .+�5   
   �� -   5         ��Name$ activityText��5      $
��Left=�6M   $��82��6h   $��	10,10,0,0q�6t   	 �� TextWrapping$
	 Wrap=�6�   $	��Top=�6�   $	��224��6�   ��6(   �� *Action+
 �� Mode$
 TwoWay=�6�   �� 5   
   -   5        $ timeTextBox��5      $
��Left=�6J   $��23��6e   $��	36,97,0,0q�6q   $
	 Wrap=�6�   $	��Top=�6�   $��58��6�    �� TextAlignment$ Center=�6�   ��6'   �� *Time+$
 TwoWay=�6�   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$
 date��5      $
��Left=�6N   $��	99,97,0,0q�6i   $	��Top=�6|      FirstDayOfWeek$ Monday=�6�   ���	#FF7E7575   SelectedDate 6#   �� *Date+$
 TwoWay=�6�   �� 5   
   -   5         ��Name$ 
saveButton��5      $��Zapisz��6%   $
��Left=�6V   $��
56,132,0,0q�6q   $	��Top=�6�   $��75��6�   ��66   �� *SaveCommand+6�   �� 5   
   -   5        $ cancelButton��5      $��Anuluj��6'   $
��Left=�6�   $��147,132,0,0q�6�   $	��Top=�6�   $��75��6�   ��68   �� *CancelCommand+��6Z   ��  �� ElementName$ editorWindow��6�   5      5      