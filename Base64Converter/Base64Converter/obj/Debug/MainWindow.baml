   M S B A M L   `   `   `  ����J  FBase64Converter, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Base64ConverterBase64Converter  5   	        Base64Converter.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:Base64Converter     5   	     � Title$  Base64 converter��5   	   $	��650��6"   $	��900��6/    � WindowStartupLocation$ CenterScreen=�6;   .��5	      � .+�5
   
   �� -   5         ��Name$ B64box��5
      $
��Left=�6"   $	��573��6=   $��
171,24,0,0q�6J    �� TextWrapping$
 Wrap=�6^   $	��Top=�6r   $	��697��6�   �� 5   
   -   5         ��Name$ SubmitButton��5      $��Convert��6'   $
��Left=�69   $��
20,531,0,0q�6T   $	��Top=�6h   $	��133��6�   $��66��6�   $��14(�6�    � Cursor$
 Hand��6�    � ToolTip 5      �� 5      .+�5      �� $
��Bold"�6    	Convert6;   �� 5      ��Decodes the base64-encoded string in the text field and places the output in an output file. Also resets the output file, so you do not accidentally overwrite5   \   5      5      �� 5   
   -   5        $ FileSelectorButton��5      $��Select input file��6-   $
��Left=�6I   $��	20,24,0,0q�6d   $	��Top=�6w   $	��133��6�   $��66��6�   $��14(�6�   $
 Hand��6�    5      �� 5      .+�5      �� $
��Bold"�6    
Input file6>   �� 5      97If you want to open a base64-encoded string from a file6Y   5      5      �� 5   
   -   5        $ OutputSelectorButton��5      $��Select output file��6/   $
��Left=�6L   $��
20,266,0,0q�6g   $	��Top=�6{   $	��133��6�   $��66��6�   $��14(�6�   4  .System.Windows.Automation.AutomationProperties   HelpText$P JIf you want the output written to a specific file, you can choose it here.��6�   $
 Hand��6G   5      �� 5      .+�5      �� $
��Bold"�6    Output file6?   �� 5       zxIf you don't select an output file, a pdf file called output_[timestamp] will be generated in the Base64converter folder6�   5!      5#      �� 5$   
   -   5        $ OutputResetButton��5$      $��Reset to default��6,   $
��Left=�6G   $��
20,347,0,0q�6b   $	��Top=�6v   $	��133��6�   $��66��6�   $��14(�6�   $9 3If you want to just use the default output filename��6�   $y�Hidden=�6   5%      �� 5&      .+�5'      �� $
��Bold"�6    Reset output6@   �� 5(      MKForgets your selected output file and defaults to generating a new pdf file6m   5)      5+      5-      5.      