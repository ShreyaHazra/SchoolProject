<style>



.myTextAreaInput{height: 45px;}

.inputText{width: 100px !important;}

</style>

<?php 

$check='';//print_r($allAnalysisList);

foreach($allAnalysisList as $a){if($a->reject_flag=='' ||$a->reject_flag=='Accepted' || $a->reject_flag=='Onhold'){$check='Avail';}}

?>

<section class="rightSide">

  <div class="tabContainer active">

    <div class="editFormPanel ">

      <h4>





<input type="button" value="Change Request Details" id="Change_Action_Details_btn" onclick="show_div('Change_Action_Details');setColor('Change_Action_Details_btn');" />

<input type="button" value="Change Request Analysis" id="Change_Action_Analysis_btn" onclick="show_div('Change_Action_Analysis');setColor('Change_Action_Analysis_btn');" />

<input type="button" value="Change Request Task" id="Change_Action_Task_btn" onclick="show_div('Change_Action_Task');setColor('Change_Action_Task_btn');" />

      </h4>

        <div class="clearfix">

          <?php if(isset($succmsg) && $succmsg != ""){?>

          <div align="center">

            <div class="nNote nSuccess" style="color:green; font-weight:bold;">

              <p><?php echo stripslashes($succmsg);?></p>

            </div>

          </div>

          <?php } ?>

          <?php if(validation_errors() != FALSE){?><div align="center"><div class="nNote nFailure" style="color:red; font-weight:bold;"> <?php echo validation_errors('<p>', '</p>'); ?></div></div><?php } ?>

        </div>





<?php ############################################################################# ?>

<div class="editFormBox clearfix colorThree Change_Action_Details">

    <h4>Change Request Details </h4>   

    <div class="editFormBoxDiv clearfix">

          <div class="propertyListingTable">

		  		<table width="99%" border="0" cellspacing="0" cellpadding="0">

                <thead><tr>	<th align="left" width="10%">#Change Request ID</th>

                			<th align="left" width="30%">Task Note</th>

                            <th align="left" width="35%">Description</th>

                            <th align="left" width="10%">Open Date</th>

                            <th align="left" width="15%"></th>

                            </tr>

                </thead><tbody>

<?php foreach($changeDataList as $cD){?>                

        <tr id="row_<?php echo $cD->change_id;?>">

        <td><?php echo $cD->change_id;?></td>        

        <td><?php echo $cD->change_task_note;?></td>

        <td><?php echo $cD->change_task_description; ?></td>   

      	<td><?php echo $cD->change_ticket_date; ?></td>

        <td><?php 

		if($attachList){

			foreach($attachList as $attach){

				if($attach->change_id==$cD->change_id ){ ?>

					<a href="<?=FRONTEND_URL?>changemgmt/download/<?=$attach->change_att_id?>"><?=$attach->change_att_name?></a>

                    

			<?php	}

			}

		}

		

		

		 ?></td>

        </tr>

<?php }?>               

				</tbody>

	           	</table>

		  </div>

    </div>

</div>

<?php ###########################################################################?>

<?php 

$change_assign_status='';

$change_assign_done='';

$change_description='';

$change_analyst_id='';

$change_analyst_completion_date='';

$rejection_note='';

$change_analysis_done='';

$task_status='';

$module_status='';

$task_created='';

$task_or_module_done='';







$change_ticket_status='';

$hold_note='';





foreach($changeDataList as $c){

$change_assign_status=$c->change_assign_status;	

$change_assign_done=$c->change_assign_done;

$change_description=$c->change_description;

$change_analyst_id=$c->change_analyst_id;

$change_analyst_completion_date=$c->change_analyst_completion_date;	

$rejection_note=$c->rejection_note;

$change_analysis_done=$c->change_analysis_done;

$task_status=$c->task_status;

$module_status=$c->module_status;

$task_created=$c->task_created;

$task_or_module_done=$c->task_or_module_done;





$change_ticket_status=$c->change_ticket_status;

$hold_note=$c->hold_note;



	}?>

<?php ############################################################################# ?>

<?php if($change_assign_done=='N' ||($change_assign_status=='HOLD' && $change_ticket_status == 'ON HOLD' )){?>

<div class="editFormBox clearfix colorThree Change_Action_Details">

    <h4>Change Request Approval </h4>   

<form name="deptFrm" method="post" action="<?php echo FRONTEND_URL;?>changemgmt/saveTmprovementForChange" class="main" enctype="multipart/form-data" id="deptFrm">    

<input type="hidden" name="task_id" value="<?php echo $task_id;?>" />

<input type="hidden" name="change_request_id" value="<?php echo $change_request_id;?>" />

<input type="hidden" name="module_type" value="<?=$module_type?>" />

	<div class="editFormBoxIn">

    	<div class="editFormBoxDiv clearfix">

          <div class="editFormBoxLt"> 

          	<label>Accept/Reject Change :<em>*</em></label>

            <div class="filedDiv"><select name="improvementForChange" id="improvementForChange" required onchange="myRequiredAdd();">

            	<option value="">--Select--</option>

                  <option value="Onhold"<?php if($change_ticket_status == 'ON HOLD') echo 'selected'; ?>>On Hold</option>

                <option value="Accepted">Accept</option>

                <option value="Rejected">Reject</option></select></div>

           </div>

           <div class="editFormBoxRt"> 

          	<label></label>

            <div class="filedDiv"><label><em>

            

            <?php 

			if($change_ticket_status == 'ON HOLD'){

				echo $hold_note;

				

			}

			

			?>

            </em></label></div>

           </div>

           

           </div>

           <div class="editFormBoxDiv clearfix">

           <div class="editFormBoxLt hideNShow"> 

          	<label>Change Details  :<em>*</em></label>

            <div class="filedDiv"><textarea class="myTextAreaInput"  name="change_details" id="change_details"></textarea></div>

           </div>

        </div>

        <div class="editFormBoxDiv clearfix">

          <div class="editFormBoxLt hideNShow">          

            <label>Change Analyser  :<em>*</em></label>

            <div class="filedDiv"><select name="changeAnalyser" id="changeAnalyser">

            <option value="">---Select Analyser---</option>

            <?php foreach($empList as $aList){?><option value="<?=$aList->emp_id?>"><?=$aList->empname?></option><?php }?>

            </select></div>

          </div>

          <div class="editFormBoxRt hideNShow">

                <label>Change Request Completion Date : <em> * </em></label>

                <div class="filedDiv"><input type="text" class="datepicker" name="complitionDate" id="complitionDate" /></div>

          </div>

        </div>

     	<div class="editFormBoxDiv clearfix">

          <div class="editFormBoxLt hideNShowRev">

          	<label> Rejection/Hold Note : <em> * </em></label>

            <div class="filedDiv"><textarea class="myTextAreaInput"  name="rejection_notes" id="rejection_notes"></textarea></div>

          </div>

     	  <div class="editFormBoxRt">

            <div class="filedDiv"><input type="submit" value="Submit" name="submitForm" /></div>

          </div>

        </div>

     </div>

</form>

</div>

<?php }else{ 

if($change_assign_status=='R'){?>

<div class="editFormBox clearfix colorThree Change_Action_Details">

    <h4>Change Request Approval </h4>   

	<div class="editFormBoxIn">

    	<div class="editFormBoxDiv clearfix">

          <div class="editFormBoxLt">

          	<label>Improvement taken for Change :<em></em></label>

            <div class="filedDiv"><label><em><?php echo 'Rejected'; ?></em></label></div>

          </div>

     	  <div class="editFormBoxRt">

          	<label>Rejection Note :<em></em></label>

            <div class="filedDiv"><label><em><?=$rejection_note; ?></em></label></div>

          </div>

        </div>

    </div>

</div>

<?php }elseif($change_assign_status=='Y'){ ?>



<div class="editFormBox clearfix colorThree Change_Action_Details">

    <h4>Change Request Approval </h4>   

	<div class="editFormBoxIn">

    	<div class="editFormBoxDiv clearfix">

          <div class="editFormBoxLt"> 

          	<label>Change Status:<em></em></label>

            <div class="filedDiv"><label><?php echo 'Accepted'; ?><em></em></label></div>

           </div>

           <div class="editFormBoxRt"> 

          	<label>Change Details  :<em></em></label>

            <div class="filedDiv"><label><?=$change_description?><em></em></label></div>

           </div>

        </div>

        <div class="editFormBoxDiv clearfix">

          <div class="editFormBoxLt">          

            <label>Change Analyser  :<em></em></label>

            <div class="filedDiv"><label><?php foreach($empList as $aList){if($change_analyst_id==$aList->emp_id){echo $aList->empname;}}?><em></em></label></div>

          </div>

          <div class="editFormBoxRt">

                <label>Expexted Analysis Completion Date : <em>  </em></label>

                <div class="filedDiv"><label><?=$change_analyst_completion_date?><em></em></label></div>

          </div>

        </div>

     </div>

</div>	

<?php if($check=='Avail'){$change_analysis_id='';

foreach($allAnalysisList as $a){

	//if($a->reject_flag==''){

		$change_analysis_id=$a->change_a_id?>

<div class="editFormBox clearfix Change_Action_Analysis">

	<h4>Analysis for Change Request</h4>

    <div class="editFormBoxIn">

        <div class="editFormBoxDiv clearfix">

          <div class="editFormBoxLt">

            <label> Change Analysis Id : <em></em></label>

            <div class="filedDiv"><label> <?=$change_analysis_id?><em></em></label></div>

          </div>

          <div class="editFormBoxRt">

          </div>

        </div>

        <div class="editFormBoxDiv clearfix">

          <div class="editFormBoxLt">

            <label> What<em></em></label>

            <div class="filedDiv"><label> <?=$a->change_a_one_w?><em></em></label></div>

          </div>

          <div class="editFormBoxRt">

            <label> When<em></em></label>

            <div class="filedDiv"><label> <?=$a->change_a_two_w?><em></em></label></div>

          </div>

        </div>

        <div class="editFormBoxDiv clearfix">

          <div class="editFormBoxLt">

            <label> Who<em></em></label>

            <div class="filedDiv"><label> <?php foreach($allEmpList as $val) { if($a->change_a_three_w==$val->emp_id){echo $val->empname;}}?><em></em></label></div>

          </div>

          <div class="editFormBoxRt">

            <label> Why<em></em></label>

            <div class="filedDiv"><label> <?=$a->change_a_four_w?><em></em></label></div>

          </div>                        

        </div>

        <div class="editFormBoxDiv clearfix">

          <div class="editFormBoxLt">

            <label> How<em></em></label>

            <div class="filedDiv"><label> <?=$a->change_a_one_h?><em></em></label></div>

          </div>

          <div class="editFormBoxRt">

            <label> Conclusion<em></em></label>

            <div class="filedDiv"><label> <?=$a->change_a_solution?><em></em></label></div>

          </div>                        

        </div>

        <div class="editFormBoxDiv clearfix">

          <div class="editFormBoxLt">

            <label> Submitted On<em></em></label>

            <div class="filedDiv"><label> <?=$a->change_submit_date?><em></em></label></div>

          </div>

          <div class="editFormBoxRt">

          <label> Status <em></em></label>

            <div class="filedDiv"><label> <em>( <?=$a->reject_flag?> )</em> 

			<?php if($a->reject_flag == 'Rejected') {echo $a->rejection_nte;}

				  if($a->reject_flag == 'Onhold') {echo $a->hold_on_nte;}

			 ?></label></div>

          </div>                        

        </div>

	</div>

</div>

<?php } //} 

if($change_analysis_done=='Y'){?>

<div class="editFormBox clearfix colorThree Change_Action_Analysis">

    <h4>Change Request Approval </h4>   

<form name="deptFrm" method="post" action="<?php echo FRONTEND_URL;?>changemgmt/saveChangeAnalysisApproval" class="main" enctype="multipart/form-data" id="deptFrm">    

<input type="hidden" name="change_analysis_id" value="<?php echo $change_analysis_id;?>" />

<input type="hidden" name="change_request_id" value="<?php echo $change_request_id;?>" />

<input type="hidden" name="task_id" value="<?php echo $task_id;?>" />

<input type="hidden" name="module_type" value="<?=$module_type?>" />

	<div class="editFormBoxIn">

    	<div class="editFormBoxDiv clearfix">

          <div class="editFormBoxLt"> 

          	<label>Change Analysis Approval:<em>*</em></label>

            <div class="filedDiv"><select name="analysisChangeApproval" id="analysisChangeApproval" required onchange="myRequiredForAnalysisAdd();">

            	<option value="">--Select--</option>

                <option value="Onhold"<?php if($change_ticket_status == 'ON HOLD') echo 'selected'; ?>>On Hold</option>

                <option value="Accepted">Accept</option>

                <option value="Rejected">Reject</option></select></div>

           </div>

           <div class="editFormBoxRt hideNShowForAnalysis"> 

          	<label> Rejection/Hold Note : <em> * </em></label>

            <div class="filedDiv"><textarea class="myTextAreaInput"  name="analysisChangerejection_notes" id="analysisChangerejection_notes"></textarea></div>

           </div>

        </div>

        <div class="editFormBoxDiv clearfix">

          <div class="editFormBoxLt"> </div>

     	  <div class="editFormBoxRt">

            <div class="filedDiv"><input type="submit" value="Submit" name="submitForm" /></div>

          </div>

        </div>

     </div>

</form>

</div>

<?php }}}?>

<?php }?>

<?php ############################################################################# ?>

<?php if($task_status=='Y' && $module_status=='N' && $task_created=='N'){?>

<div class="editFormBox clearfix Change_Action_Task">

	<h4>Task for Change Request</h4>

    <div class="editFormBoxIn" id='Tools_work'>

       <div class="editFormBoxDiv clearfix">

          <div class="editFormBoxLt">

            <div class="filedDiv"><input type="button" id="Create_Task" onClick="myEnableTaskForChange()" value="Task"></div>

          </div>

          <div class="editFormBoxRt"><input type="button" id="Change_Document" onClick="myEnableModuleForChange()" value="Module">

          </div>

       </div>        

    </div>

    <div class="editFormBoxIn" id='Doc_module'>

<form name="deptFrm" method="post" action="<?php echo FRONTEND_URL;?>changemgmt/saveModule" class="main" enctype="multipart/form-data" id="deptFrm">    

<input type="hidden" name="change_analysis_id" value="<?php echo $change_analysis_id;?>" />

<input type="hidden" name="change_request_id" value="<?php echo $change_request_id;?>" />

<input type="hidden" name="task_id" value="<?php echo $task_id;?>" />

<input type="hidden" name="module_type" value="<?=$module_type?>" />

       <div class="editFormBoxDiv clearfix">

          <div class="editFormBoxLt">

          	<label> Task Note<em></em></label>

            <div class="filedDiv"><textarea class="myTextAreaInput"  name="task_note" ></textarea></div>

          </div>

          <div class="editFormBoxRt">

          	<label> Task Description<em></em></label>

            <div class="filedDiv"><textarea class="myTextAreaInput" name="task_desc"></textarea></div>

          </div>

       </div>

       <div class="editFormBoxDiv clearfix">

          <div class="editFormBoxLt">

          	<label> Task Module<em></em></label>

            <div class="filedDiv"><select name="task_module">

            <option value="">--Select--</option><?php foreach($moduleList as $m){?>

            <option value="<?=$m->module_id?>"><?=$m->module_name?></option><?php } ?>

            </select></div>

          </div>

          <div class="editFormBoxRt"></div>

       </div>

       <div class="editFormBoxDiv clearfix">

          <div class="editFormBoxLt"><input type="button" value="Change Tool" onclick="changeTools();" /></div>

          <div class="editFormBoxRt">

            <div class="filedDiv"><input type="submit"></div>

          </div>

       </div>

</form>    

    </div>

    <div class="editFormBoxIn" id='task_module'>

<form name="deptFrm" method="post" action="<?php echo FRONTEND_URL;?>changemgmt/saveTask" class="main" enctype="multipart/form-data" id="deptFrm">    

<input type="hidden" name="change_analysis_id" value="<?php echo $change_analysis_id;?>" />

<input type="hidden" name="change_request_id" value="<?php echo $change_request_id;?>" />

<input type="hidden" name="task_id" value="<?php echo $task_id;?>" />    

<input type="hidden" name="module_type" value="<?=$module_type?>" />

       <div class="propertyListingTable">

            <table width="100%" border="0" cellspacing="0" cellpadding="0">

            <thead>

            <tr>

                    <th>Task Note</th>

                    <th>Task Description</th>

                    <th>Assign Task To</th>

                    <th>Completion Date</th>

                    <th>Assign Reviewer</th>

                    <th>Action</th>

            </tr>

            </thead>

            <tbody id="TaskList"><input type="hidden" name="counter_task" id="counter_task" value="1" /></tbody>

            <tfoot>

            <tr>	

<td><input type="text" name="task_note_1" id="task_note_1" /></td>

<td><input type="text" name="task_desc_1" id="task_desc_1" /></td>

<td><select name="assign_to_1" id="assign_to_1">

<option value="">---Select Employee---</option>

<?php foreach($taskperfEmpList as $val) { ?><option value="<?=$val->emp_id?>"><?=$val->empname?></option><?php } ?> 

</select></td>

<td><input type="text" name="completion_date_1" id="completion_date_1" class="datepicker" readonly /></td>

<td><select name="reviewed_by_1" id="reviewed_by_1">

<option value="">---Select Employee---</option>

<?php foreach($taskrevEmpList as $val) { ?><option value="<?=$val->emp_id?>"><?=$val->empname?></option><?php } ?> 

</select></td>

<td></td>

            </tr>

            <tr>

<td><strong style="padding-top: 8px;float: left;padding-right: 10px;">To Add More Task</strong><a onclick="addNewTaskFunc();"><input type="button" value="Add"></a></td>

<td colspan="5" align="right"></td>

			</tr>

            </tfoot>

            </table>

       </div>      

       <div class="editFormBoxDiv clearfix">

          <div class="editFormBoxLt"><input type="button" value="Change Tool" onclick="changeTools();" /></div>

          <div class="editFormBoxRt">

            <div class="filedDiv"><input type="submit"></div>

          </div>

       </div>

</form>       

    </div>

</div>

<?php }else{if($module_status=='N' && $task_created=='Y'){

$i=0;$checkStatus='';foreach($taskList as $tl){if($tl->module_id==0 && $tl->reject_flag==''){$i++;}}if($i>0){$checkStatus='taskList';}	

if($checkStatus=='taskList'){?>

<div class="editFormBox clearfix Change_Action_Task">

	<h4>Task List for Change Request</h4>

    <div class="editFormBoxIn">	

    	<div class="propertyListingTable">

            <table width="100%" border="0" cellspacing="0" cellpadding="0">

            <thead>

            <tr>

            		<th align="left"  width="5%"></th>

                    <th align="left"  width="5%">Task ID</th>

                    <th align="left" width="15%">Task Note</th>

                    <th align="left" width="15%">Task Description</th>

                    <th align="left" width="5%">Assign Task To</th>

                    <th align="left" width="5%">Completion Date</th>

                    <th align="left" width="15%">Solution</th>

                    <th align="left" width="10%">Assign Reviewer</th>

                    <th align="left" width="5%">Status</th>

                    <th align="left" width="10%">Rejected List</th>

            </tr>

            </thead>

            <tbody>

            <?php foreach($taskList as $tl){if($tl->module_id==0 && $tl->reject_flag==''){?>

            	<tr id="row_<?=$tl->change_task_id?>">         

<td><?php if($tl->status=='Open' or $tl->status=='In-Progress'){?><input id="check_<?php echo $tl->change_task_id;?>" type="checkbox" onclick="editTaskList('row_<?php echo $tl->change_task_id;?>','<?=$tl->change_task_id?>','<?=$change_analysis_id?>','<?=$change_request_id?>','<?=$task_id?>')"><?php } ?></td>

<td align="left" valign="middle"><?=$tl->change_task_id?></td>  

<td><?=$tl->change_task_note?></td>

<td><?=$tl->change_task_desc?></td>

<td><?php foreach($taskperfEmpList as $val) { if($tl->assign_to==$val->emp_id){echo $val->empname;}}?></td>



<td><?=$tl->completion_date?></td>

<td><?=($tl->solution=='')?'NA':$tl->solution?></td>

<td><?php foreach($taskrevEmpList as $rvwEmp){if($rvwEmp->emp_id==$tl->reviewer){echo $rvwEmp->empname;}} ?></td>

<td><?=$tl->status?></td>

<td><?php if($tl->rejected_task_ids<>''){?><input type="button" onclick="rejectedTask('<?=$tl->rejected_task_ids?>','<?=$tl->change_task_id?>');" value="Show-History" id="history_<?=$tl->change_task_id?>" /><?php }else{echo '';} ?></td>

                </tr>

            <?php }}?>

            </tbody>

            </table>

        </div>

    </div>

<?php if($task_or_module_done=='N'){?>    

    <div class="editFormBoxIn">

<form name="deptFrm" method="post" action="<?php echo FRONTEND_URL;?>changemgmt/saveTask" class="main" enctype="multipart/form-data" id="deptFrm">    

<input type="hidden" name="change_analysis_id" value="<?php echo $change_analysis_id;?>" />

<input type="hidden" name="change_request_id" value="<?php echo $change_request_id;?>" />

<input type="hidden" name="task_id" value="<?php echo $task_id;?>" />  

<input type="hidden" name="module_type" value="<?=$module_type?>" />  

       <div class="propertyListingTable">

            <table width="100%" border="0" cellspacing="0" cellpadding="0">

            <thead>

            <tr>

                    <th>Task Note</th>

                    <th>Task Description</th>

                    <th>Assign Task To</th>

                    <th>Completion Date</th>

                    <th>Reviewer</th>

                    <th>Action</th>

            </tr>

            </thead>

            <tbody id="TaskList"><input type="hidden" name="counter_task" id="counter_task" value="1" /></tbody>

            <tfoot>

            <tr>	

<td><input type="text" name="task_note_1" id="task_note_1" /></td>

<td><input type="text" name="task_desc_1" id="task_desc_1" /></td>

<td><select name="assign_to_1" id="assign_to_1">

<option value="">---Select Employee---</option>

<?php foreach($taskperfEmpList as $val) { ?><option value="<?=$val->emp_id?>"><?=$val->empname?></option><?php } ?> 

</select></td>

<td><input type="text" name="completion_date_1" id="completion_date_1" class="datepicker" readonly /></td>

<td><select name="reviewed_by_1" id="reviewed_by_1">

<option value="">---Select Employee---</option>

<?php foreach($taskrevEmpList as $val) { ?><option value="<?=$val->emp_id?>"><?=$val->empname?></option><?php } ?> 

</select></td>

<td><input type="submit"></td>



            </tr>

            </tfoot>

            </table>

       </div>      

</form>       

    </div>

<?php }?>    

</div>	

<?php }}

if($module_status=='Y' && $task_created=='N'){

foreach($taskList as $tl){if($tl->module_id>0){//print_r($taskList);?>

<div class="editFormBox clearfix Change_Action_Task">

	<h4>Module for Change Request</h4>

    <div class="editFormBoxIn">

    	<div class="editFormBoxDiv clearfix">

          <div class="editFormBoxLt">

          	<label>Task Note<em></em></label>

            <div class="filedDiv"><label><?=$tl->change_task_note?><em></em></label></div>

          </div>

          <div class="editFormBoxRt">

          	<label>Task Description<em></em></label>

            <div class="filedDiv"><label><?=$tl->change_task_desc?><em></em></label></div>

          </div>

       </div>

       <div class="editFormBoxDiv clearfix">

          <div class="editFormBoxLt">

          	<label>Task Module<em></em></label>

            <div class="filedDiv"><label><?php foreach($moduleList as $m){if($m->module_id==$tl->module_id){echo $m->module_name;}} ?><em></em></label></div>

          </div>

          <div class="editFormBoxRt">

          	<label>Subbmitted by<em></em></label>

            <div class="filedDiv"><label><?php foreach($allEmpList as $list){if($tl->submitted_by==$list->emp_id){echo $list->empname; }}?><em></em></label></div>

          </div>

       </div>

       <div class="editFormBoxDiv clearfix">

          <div class="editFormBoxLt">

          	<label>Subbmitted  on<em></em></label>

            <div class="filedDiv"><label><?=$tl->submitted_on?><em></em></label></div>

          </div>

          <div class="editFormBoxRt">
                
          </div>

       </div>

    </div>

</div>

<?php }}}}?>

<?php ############################################################################# ?>

<div class="editBtnSec">

  <input onclick="window.location='<?php echo FRONTEND_URL;?>changemgmt/changeRequestList/'" type="button" value="Return" name="Save" />

</div>    

    </div>

  </div>

</section>

<script>

function rejectedTask(myParam,myParam2){//alert(myParam+''+myParam2);

	if($('#history_'+myParam2).val()!='Hide-History'){

		$.ajax({

			url: '<?php echo FRONTEND_URL?>mychangeajax/rejectedTaskAjax',

			type: 'POST',

			data: {'change_task_id':myParam},

			success: function(data) {

				//alert(data);

				$('#row_'+myParam2).after(data);

			},

			error: function(e){}

		});

		$('#history_'+myParam2).val('Hide-History');

	}

	else{

		$('.row_'+myParam).hide();

		$('#history_'+myParam2).val('Show-History');

	}

}

function editTaskList(row_id,change_task_id,analysis_id,change_id,task_id){

	var module_type=<?=$this->uri->segment(4)?>;

	$.ajax({

			url: '<?php echo FRONTEND_URL?>mychangeajax/editTaskListAjax',

			type: 'POST',

			data: {'change_task_id' : change_task_id , 'change_id' : change_id , 'task_id' : task_id ,'module_type': module_type},

			success: function(data) {//alert(data);

				$('#'+row_id).after(data);

				$('#'+row_id).hide();

			},

			error: function(e){}

		});

}

function hideEditTaskList(myParam){//alert(myParam);

	$('#row_'+myParam+'_Edit').hide();

	$('#row_'+myParam).show();

	$('#check_'+myParam).attr( "checked",false )

}

function myRejecttionNote(myParam){

	if($('#review_'+myParam).val()=='Reject'){

		$('#rejection_note_'+myParam).show();

	}else{

		$('#rejection_note_'+myParam).hide();

	}

}



function addNewTaskFunc(){

	var count=$('#counter_task').val();//alert(count);

	var task_note=$('#task_note_1').val();

	var task_desc=$('#task_desc_1').val();

	var assign_to=$('#assign_to_1').val();

	var completion_date=$('#completion_date_1').val();

	var reviewed_by=$('#reviewed_by_1').val();

	if(task_note != '' && task_desc != '' && assign_to != '' && completion_date != '' && reviewed_by != ''){

		count++;

		$.ajax({

			url: '<?php echo FRONTEND_URL?>mychangeajax/createTaskListAjax',

			type: 'POST',

			data: {'count' : count , 'task_note' : task_note , 'task_desc' : task_desc , 'assign_to' : assign_to , 'completion_date' : completion_date , 'reviewed_by' : reviewed_by},

			success: function(data) {//alert(data);

				$('#TaskList').after(data);

				$('#task_note_1').val('');

				$('#task_desc_1').val('');

				$('#assign_to_1').val('');

				$('#completion_date_1').val('');

				$('#reviewed_by_1').val('');

				$('#counter_task').val(count);

			},

			error: function(e){}

		});

	}

}

function myDeleteTask(myParam){var blank='';//alert(myParam);

	$('#task_note_'+myParam).val(blank);

	$('#task_desc_'+myParam).val(blank);

	$('#assign_to_'+myParam).val(blank);

	$('#completion_date_'+myParam).val(blank);

	$('#reviewed_by_'+myParam).val(blank);

	$('#row_'+myParam).hide();

}

function setColor(btn){//alert(btn);

	

	$('#Change_Action_Details_btn').css('background','#f2f2f2');

	$('#Change_Action_Details_btn').css('color','#163a84');

	

	$('#Change_Action_Analysis_btn').css('background','#f2f2f2');

	$('#Change_Action_Analysis_btn').css('color','#163a84');	

	$('#Change_Action_Task_btn').css('background','#f2f2f2');

	$('#Change_Action_Task_btn').css('color','#163a84');

    $('#'+btn).css('background','#163a84');

    $('#'+btn).css('color','#FFFFFF');

}

function show_div(param){//alert(param);



$('.Change_Action_Details').hide();

$('.Change_Action_Analysis').hide();

$('.Change_Action_Task').hide();

$('.'+param).show();

}

$(document).ready(function() {



$('.Change_Action_Details').show();



$('.Change_Action_Analysis').hide();

$('.Change_Action_Task').hide();

	$("#deptFrm").validate();	

		$( ".datepicker" ).datepicker({

			showButtonPanel: true,

			dateFormat : 'yy-mm-dd',

			changeMonth: true,

			changeYear: true,

			numberOfMonths: 1,

			minDate : 0

		});

});

$('#Doc_module').hide();

$('#task_module').hide();

$('.hideNShow').hide();

$('.hideNShowRev').hide();

$('.hideNShowForAnalysis').hide();

function myEnableTaskForChange(){

	$('#Tools_work').hide();

	$('#Doc_module').hide();

	$('#task_module').show();

}

function myEnableModuleForChange(){

	$('#Tools_work').hide();

	$('#Doc_module').show();

	$('#task_module').hide();

}

function myRequiredAdd(){

	var improvementForChange=$('#improvementForChange').val();

	if(improvementForChange=='Accepted'){

		$('#Change_Action_Details').attr('required','true');

		$('#changeAnalyser').attr('required','true');

		$('#complitionDate').attr('required','true');

		$('#changeAnalysisType').attr('required','true');

		$('.hideNShow').show();

		$('#rejection_notes').removeAttr('required');

		$('.hideNShowRev').hide();

	}else{

		$('.hideNShowRev').show();

		$('.hideNShow').hide();

		$('#rejection_notes').attr('required','true');

		$('#Change_Action_Details').removeAttr('required');

		$('#changeAnalyser').removeAttr('required');

		$('#complitionDate').removeAttr('required');

		$('#changeAnalysisType').removeAttr('required');

	}

}

function myRequiredForAnalysisAdd(){

	var analysisChangeApproval=$('#analysisChangeApproval').val();

	if(analysisChangeApproval=='Accepted'){

		$('#analysisChangerejection_notes').removeAttr('required');

		$('.hideNShowForAnalysis').hide();

	}else{

		$('.hideNShowForAnalysis').show();

		$('#analysisChangerejection_notes').attr('required','true');

	}

}

function changeTools(){

	$('#Doc_module').hide();

	$('#task_module').hide();

	$('#Tools_work').show();

	//$('#countMaxCauseEffect').val(0);	

}

</script>

