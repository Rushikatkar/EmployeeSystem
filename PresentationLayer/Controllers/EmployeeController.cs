using BAL;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PresentationLayer.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IPositionService _positionService;
        private readonly ILogger<EmployeeController> _logger;

        // Constructor injection for EmployeeService and Logger
        public EmployeeController(IEmployeeService employeeService,
            ILogger<EmployeeController> logger,
            IPositionService positionService)
        {
            _employeeService = employeeService;
            _logger = logger;
            _positionService = positionService;
        }

        // Index Action - GET (List all employees)
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var employees = await _employeeService.GetAllEmployeesAsync();
                _logger.LogInformation("Fetched employee list successfully.");
                return View(employees);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching employee list.");
                return View("Error");
            }
        }

        // Create Action - GET
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.PositionId = _positionService.GetPositionsAsync().Result.
                Select(p => new SelectListItem()
                { Value = p.Id.ToString(), Text = p.Name });

            _logger.LogInformation("Accessed Create Employee form.");
            return View();
        }

        // Create Action - POST
        [HttpPost]
        public async Task<IActionResult> Create(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Employee creation failed due to validation errors.");
                ViewBag.PositionId = _positionService.GetPositionsAsync().Result.
                Select(p => new SelectListItem()
                { Value = p.Id.ToString(), Text = p.Name });
                return View(employee);
            }

            try
            {
                // Normalize email to lowercase
                employee.Email = employee.Email?.ToLowerInvariant();

                await _employeeService.AddEmployeeAsync(employee);
                _logger.LogInformation("Employee created successfully. Employee Name: {EmployeeName}", employee.Name);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating employee.");
                ModelState.AddModelError("", "An error occurred while saving the employee.");

                ViewBag.PositionId = _positionService.GetPositionsAsync().Result.
                Select(p => new SelectListItem()
                { Value = p.Id.ToString(), Text = p.Name });
                return View(employee);
            }
        }

        // Edit Action - GET
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var employee = await _employeeService.GetEmployeeByIdAsync(id);
                if (employee == null)
                {
                    _logger.LogWarning("Employee not found for editing. Employee ID: {EmployeeId}", id);
                    return NotFound();
                }

                _logger.LogInformation("Accessed Edit form for Employee ID: {EmployeeId}", id);

                ViewBag.PositionId = _positionService.GetPositionsAsync().Result.
                Select(p => new SelectListItem()
                { Value = p.Id.ToString(), Text = p.Name, Selected = p.Id == employee.PositionId });

                return View(employee);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while accessing Edit form.");

                ViewBag.PositionId = _positionService.GetPositionsAsync().Result.
                Select(p => new SelectListItem()
                { Value = p.Id.ToString(), Text = p.Name });
                return View("Error");
            }
        }

        // Edit Action - POST
        [HttpPost]
        public async Task<IActionResult> Edit(Employee updatedEmployee)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Employee update failed due to validation errors.");
                return View(updatedEmployee);
            }

            try
            {
                // Normalize email to lowercase
                updatedEmployee.Email = updatedEmployee.Email?.ToLowerInvariant();

                await _employeeService.UpdateEmployeeAsync(updatedEmployee);
                _logger.LogInformation("Employee updated successfully. Employee ID: {EmployeeId}", updatedEmployee.Id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating employee. Employee ID: {EmployeeId}", updatedEmployee.Id);
                ModelState.AddModelError("", "An error occurred while updating the employee.");

                ViewBag.PositionId = _positionService.GetPositionsAsync().Result.
                Select(p => new SelectListItem()
                { Value = p.Id.ToString(), Text = p.Name });
                return View(updatedEmployee);
            }
        }

        // Details Action - GET
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var employee = await _employeeService.GetEmployeeByIdAsync(id);
                if (employee == null)
                {
                    _logger.LogWarning("Employee not found for details. Employee ID: {EmployeeId}", id);
                    return NotFound();
                }

                _logger.LogInformation("Fetched details for employee: {EmployeeName}", employee.Name);
                return View(employee);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching employee details.");
                return View("Error");
            }
        }

        // Delete Action - GET
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var employee = await _employeeService.GetEmployeeByIdAsync(id);
                if (employee == null)
                {
                    _logger.LogWarning("Employee not found for deletion. Employee ID: {EmployeeId}", id);
                    return NotFound();
                }

                _logger.LogInformation("Accessed Delete confirmation form for Employee ID: {EmployeeId}", id);
                return View(employee);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while accessing Delete confirmation form.");
                return View("Error");
            }
        }

        // Delete Action - POST
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _employeeService.DeleteEmployeeAsync(id);
                _logger.LogInformation("Employee deleted successfully. Employee ID: {EmployeeId}", id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting employee. Employee ID: {EmployeeId}", id);
                return View("Error");
            }
        }
    }
}
