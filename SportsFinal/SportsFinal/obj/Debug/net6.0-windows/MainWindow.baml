   M S B A M L   `   `   `  ����F  BSportsFinal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:SportsFinalSportsFinal  5   	       SportsFinal.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:SportsFinal     5   	     � Title$  	SportsApp��5   	   $	��450��6   $	��800��6(   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6    �� DisplayMemberPath$
 Name��6A   $��10q�6   ��6"   �� *Sports+ �� SelectedItem 6Z   �� *ChosenSport+6   �� 5   
   $��1��6   $
 Name��6@   $��10q�6~   ��6"   �� *Teams+ 6Y   �� *ChosenTeams+6~   �� 5   
   $��2��6   $
 Name��6B   $��10q�6�   ��6"   �� *	Players+ 6[   �� *ChosenPlayer+6�   �� 5   
   $��0��6    �� Orientation$ 
Horizontal=�6%   $	��Top=�6>   .+�5      �� $��	Add Sport��6   $��5q�6M   ��6)   �� *AddSportCommand+6M   �� 5      $��Remove Sport��6   $��5q�6S   ��6,   �� *RemoveSportCommand+{�6^   �� *CanRemoveSport+�� 5      $��Edit Sport Name��6   $��5q�6X   ��6/   �� *EditSportNameCommand+{�6c   �� *CanEditSportName+5      �� 5   
   $��
Save Teams��6   $��5q�6J   $
��Left=�6V   $��Bottom=�6r   ��6&   �� *saveDataCommand+6r   �� 5!   
   $��1��6   $ 
Horizontal=�6%   $	��Top=�6>   .+�5"      �� $��Add Team��6   $��5q�6K   ��6(   �� *AddTeamCommand+{�6V   �� *
CanAddTeam+�� 5#      $��Remove Team��6   $��5q�6Q   ��6+   �� *RemoveTeamCommand+{�6\   �� *CanRemoveTeam+�� 5$      $��Edit Team Name��6   $��5q�6V   ��6.   �� *EditTeamNameCommand+{�6a   �� *CanEditTeamName+5%      �� 5&   
   $��
Load Teams��6   $��5q�6J   $��Right=�6U   $��Bottom=�6q   ��6&   �� *loadDataCommand+6q   �� 5+   
   $��2��6   $ 
Horizontal=�6%   $	��Top=�6>   .+�5,      �� $��
Add Player��6   $��5q�6O   ��6*   �� *AddPlayerCommand+{�6Z   �� *CanAddPlayerToTeam+�� 5-      $��Remove Player��6   $��5q�6U   ��6-   �� *RemovePlayerCommand+{�6`   �� *CanRemovePlayerFromTeam+�� 5.      $��Edit Player Name��6   $��5q�6Z   ��60   �� *EditPlayerNameCommand+{�6e   �� *CanEditPlayerName+5/      50      51      